import { Contact } from './contact';
import { KeyValuePair } from "./keyValuePair";

export interface Vehicle{
    id: string;
    model: KeyValuePair;
    make: KeyValuePair;
    isRegistered: boolean;
    features: KeyValuePair[];
    contact: Contact;
    lastUpdate: string;
}
