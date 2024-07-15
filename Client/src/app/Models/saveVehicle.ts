import { Contact } from "./contact";

export interface SaveVehicle{
    id: string;
    modelId: string;
    makeId: string;
    isRegistered: boolean;
    features: string[];
    contact: Contact;
}