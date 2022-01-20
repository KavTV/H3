#python snmp trap receiver
from pysnmp.entity import engine, config
from pysnmp.carrier.asyncore.dgram import udp
from pysnmp.entity.rfc3413 import ntfrcv
import logging

class trap:

    jens = []
    def start(self,snmpEngine, meth):


        TrapAgentAddress='172.16.4.4'; #Trap listerner address
        Port=162;  #trap listerner port

        print("Listening to trap "+TrapAgentAddress+" , Port : " +str(Port));
        config.addTransport(
            snmpEngine,
            udp.domainName + (1,),
            udp.UdpTransport().openServerMode((TrapAgentAddress, Port))
        )

        #Configure community here
        config.addV1System(snmpEngine, 'my-area', 'ciscolab')

        ntfrcv.NotificationReceiver(snmpEngine, meth)

        snmpEngine.transportDispatcher.jobStarted(1)  

        try:
            snmpEngine.transportDispatcher.runDispatcher()
        except:
            snmpEngine.transportDispatcher.closeDispatcher()
            raise