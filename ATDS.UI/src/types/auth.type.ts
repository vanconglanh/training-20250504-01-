import { PermissionAction } from "@/config/enum/PermissionAction";

export interface Profile {
  userId: number;
  userName: string;
  password: string;
  language: string;
  email: string;
  passwordHash: string;
  role: string;
  status: string;
  createdAt: string; // ISO string
  updatedAt: string; // ISO string
  yukoFlag: number;
  permissions: Permission[];
  id: string;
  username: string;
  fullName?: string;
}

export interface Permission {
  screenName: string;
  actionName: PermissionAction[];
}