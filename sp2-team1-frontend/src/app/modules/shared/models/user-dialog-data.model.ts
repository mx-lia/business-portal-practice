import { User } from './user.model';

export interface UserDialogData {
    action: string;
    user: User;
}