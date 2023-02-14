import { Contact } from './contact';

export type Lead = {
  id: string;
  jobId: number;
  contact: Contact;
  description: string;
  category: string;
  suburb: string;
  price: number;
  acceptedPrice: number;
  createdAt: string;
};
