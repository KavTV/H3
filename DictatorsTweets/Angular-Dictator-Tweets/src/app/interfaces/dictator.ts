import { BehaviorSubject, Observable } from "rxjs";
import { TwitterMessage } from "./twitter-message";

export interface Dictator {
    name: string;
    description: string;
    twitterKey: string;
    tweets: BehaviorSubject<TwitterMessage[]>
}
