import { AssignedTag } from "./assigned-tag";

export interface User {
  bannerId: number;
  username: string;
  firstName: string;
  lastName: string;
  email: string;
  businessAddress: string;
  displayInDirectory: boolean;
  emailNotification: boolean;
  assignedTags: AssignedTag[];
}
