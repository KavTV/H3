from queue import Empty
import tkinter as tk
from pysnmp import hlapi
from netmiko import ConnectHandler
from functools import partial
from trapReciever import *
from threading import *


class interface: 
    def __init__(self, interface, status): 
        self.interface = interface 
        self.status = status

class vlan:
    def __init__(self, name): 
        self.name = name 

cisco_881 = {
    'device_type': 'cisco_ios',
    'host':   '172.16.4.2',
    'username': 'admin',
    'password': 'Kode1234',
    'port' : 22,          # optional, defaults to 22
    'secret': 'Kode1234',     # optional, defaults to ''
}

net_connect = ConnectHandler(**cisco_881)

#The usual get snmp get command
def get(target, oids, credentials, port=161, engine=hlapi.SnmpEngine(), context=hlapi.ContextData()):
    handler = hlapi.getCmd(
        engine,
        credentials,
        hlapi.UdpTransportTarget((target, port)),
        context,
        *construct_object_types(oids)
    )
    return fetch(handler, 1)[0]

#Get a bulk of information from oids
def get_bulk(target, oids, credentials, count, start_from=0, port=161,
             engine=hlapi.SnmpEngine(), context=hlapi.ContextData()):
    handler = hlapi.bulkCmd(
        engine,
        credentials,
        hlapi.UdpTransportTarget((target, port)),
        context,
        start_from, count,
        *construct_object_types(oids)
    )
    return fetch(handler, count)


def get_bulk_auto(target, oids, credentials, count_oid, start_from=0, port=161,
                  engine=hlapi.SnmpEngine(), context=hlapi.ContextData()):
    count = get(target, [count_oid], credentials, port, engine, context)[count_oid]
    return get_bulk(target, oids, credentials, count, start_from, port, engine, context)

#Get the specific oids values
def fetch(handler, count):
    result = []
    for i in range(count):
        try:
            error_indication, error_status, error_index, var_binds = next(handler)
            if not error_indication and not error_status:
                items = {}
                for var_bind in var_binds:
                    items[str(var_bind[0])] = cast(var_bind[1])
                result.append(items)
            else:
                raise RuntimeError('Got SNMP error: {0}'.format(error_indication))
        except StopIteration:
            break
    return result

#Simplified get
def get_snmp(target, oid):
    return get(target, oid, hlapi.CommunityData('ciscolab'))

#Simplified get bulk
def bulk_snmp(target, oids, count):
    return get_bulk(target, oids, hlapi.CommunityData('ciscolab'), count)
    


def construct_object_types(list_of_oids):
    object_types = []
    for oid in list_of_oids:
        object_types.append(hlapi.ObjectType(hlapi.ObjectIdentity(oid)))
    return object_types



def cast(value):
    try:
        return int(value)
    except (ValueError, TypeError):
        try:
            return float(value)
        except (ValueError, TypeError):
            try:
                return str(value)
            except (ValueError, TypeError):
                pass
    return value

def snmp_intafaces():
    foundinterfaces = bulk_snmp('172.16.4.2',['1.3.6.1.2.1.2.2.1.2','1.3.6.1.2.1.2.2.1.8'], 25)
    interfaces = []
    for dic in foundinterfaces:
        intface = interface("fastEthernet0/1","down")
        for k, v in dic.items():
            if isinstance(v, int):
                if v == 1:
                    intface.status = "up"
                elif v == 2:
                    intface.status = "down"
                else:
                    intface.status = "testing"
            else:
                intface.interface = v
        interfaces.append(intface)
    return interfaces

def snmp_vlans():
    foundvlans = bulk_snmp('172.16.4.2',['1.3.6.1.4.1.9.9.46.1.3.1.1.4.1'], 7)
    vlans = []
    for dic in foundvlans:
        lan = vlan("")
        for k, v in dic.items():
            lan.name = str(v)
        vlans.append(lan)
    return vlans


def send_interface_shutdown_task(interface):
    shutdownthread = Thread(target=send_interface_shutdown, args=(interface,))
    shutdownthread.start()
    


def send_interface_shutdown(interface):
    net_connect.enable()
    net_connect.config_mode()
    net_connect.send_command_timing("interface " + interface.interface)

    if  interface.status == "up":
        print("CLOSING PORT")
        net_connect.send_command_timing("shutdown")
    elif interface.status == "down" or "administratively down":
        print("OPENING PORT")
        net_connect.send_command_timing("no shutdown")
    else:
        #Default is shutdown, could change this later.
        print("CLOSING PORT")
        net_connect.send_command_timing("shutdown")
    #Go back to normal
    net_connect.save_config()
    net_connect.exit_config_mode()
    net_connect.exit_enable_mode()


buttons = []

def generate_port_layout(interfaces):
    gridrow = 0
    gridcolumn = 0
    for interface in interfaces:
        gridcolumn = gridcolumn + 1
    
        #Change the color depending on the status of the interface
        btn_color = getInterfaceColor(interface.status)

        bt = tk.Button(
            text=interface.interface,
            width=25,
            height=5,
            bg=btn_color,
            fg="yellow",
            command= partial(send_interface_shutdown_task, interface)
        )
        bt.grid(row=gridrow, column= gridcolumn, padx=10, pady=10)

        #Save the button to array
        buttons.append(bt)

        #We only want a row with 5 columns
        if gridcolumn > 4:
            gridcolumn = 0
            gridrow = gridrow + 1


def generate_vlan_layout(vlans):
    gridcolumn = 0
    gridrow = 8

    headertxt = tk.StringVar()
    headertxt.set("VLANS")
    tk.Label(window, textvariable=headertxt).grid(row=7, column= 3, padx=10, pady=10)

    for vlan in vlans:
        gridcolumn = gridcolumn + 1
        txt = tk.StringVar()
        txt.set(vlan.name)
        tk.Label(window, textvariable=txt).grid(row=gridrow, column= gridcolumn, padx=10, pady=10)

        #We only want a row with 5 columns
        if gridcolumn > 4:
            gridcolumn = 0
            gridrow = gridrow + 1


def init_layout(interfaces, vlans):
    generate_port_layout(interfaces)
    generate_vlan_layout(vlans)


def getButton(text):
    for item in buttons:
        if item['text'] == str(text):
            return item

#This method gets called every time a new trap i recieved
def notif(snmpEngine, stateReference, contextEngineId, contextName,
                varBinds, cbCtx):

    intface = interface("","")
    #We only want the oids that refer to the interface name and the status which is those oids
    for name, val in varBinds:
        if "1.3.6.1.4.1.9.2.2.1.1.20.1" in str(name):
            intface.status = str(val)
        elif "1.3.6.1.2.1.2.2.1.2.1" in str(name):
            intface.interface = str(val)
    if intface.interface != "" and intface.status != "":
        getButton(intface.interface).configure(
            bg=getInterfaceColor(intface.status), 
            command= partial(send_interface_shutdown_task, intface)
        )


def getInterfaceColor(status):
    if status == "up":
            return "green"
    elif status == "down" or status == "administratively down":
            return "red"
    else:
        return "gray"

#Engine that is used for the reciever
snmp_engine = engine.SnmpEngine()

def trap_work():
    t = trap()
    t.start(snmp_engine, notif)
    
def closeWindow():
    snmp_engine.transportDispatcher.jobFinished(1)
    window.destroy()

#Start the window
window = tk.Tk()

#Lets get the initial interfaces and vlans
interfaces = snmp_intafaces()
vlans = snmp_vlans()

init_layout(interfaces,vlans)


#Start the trap reciever on a new thread
trapthread = Thread(target=trap_work)
trapthread.start()


#Refer to closewindow method when window is closed
window.protocol("WM_DELETE_WINDOW", closeWindow)



window.mainloop()
