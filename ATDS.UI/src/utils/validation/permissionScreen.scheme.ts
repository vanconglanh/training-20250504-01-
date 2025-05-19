// src/utils/validationSchema.ts
import { z } from 'zod';
import i18next from 'i18next';

const t = i18next.t.bind(i18next);

export const permissionScreenSchema = z.object({
    permissionId: z
    .number(),
  screenId: z
    .number(),
  status: z
    .number(),
});

export const permissionScreenEditSchema = permissionScreenSchema.extend({
 
});

export type PermissionScreenValidationSchema = z.infer<typeof permissionScreenSchema>;
export type PermissionScreenEditValidationSchema = z.infer<typeof permissionScreenEditSchema>;