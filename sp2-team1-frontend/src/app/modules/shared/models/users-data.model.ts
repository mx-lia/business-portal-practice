import { User } from './user.model';

export interface UsersData {
  countOfPages: number;
  countOfRecords: number;
  users: User[];
}
