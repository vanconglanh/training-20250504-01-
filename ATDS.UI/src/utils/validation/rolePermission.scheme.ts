// src/utils/validationSchema.ts
import { z } from 'zod';
import i18next from 'i18next';

const t = i18next.t.bind(i18next);

export const rolePermissionSchema = z.object({
    roleId: z
    .number(),
  permissionScreenId: z
    .number(),
  status: z
    .number(),
});

export const rolePermissionEditSchema = rolePermissionSchema.extend({
 
});

export type RolePermissionValidationSchema = z.infer<typeof rolePermissionSchema>;
export type RolePermissionEditValidationSchema = z.infer<typeof rolePermissionEditSchema>;