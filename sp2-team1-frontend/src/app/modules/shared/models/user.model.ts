import { Roles } from '@app/modules/shared/models/roles.model';

export interface User {
    id: number;
    userName: string;
    password: string;
    email: string;
    role: Roles;
}
