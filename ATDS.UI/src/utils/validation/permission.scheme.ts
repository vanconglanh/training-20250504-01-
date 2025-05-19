// src/utils/validationSchema.ts
import { z } from 'zod';
import i18next from 'i18next';

const t = i18next.t.bind(i18next);

export const permissionSchema = z.object({
    name: z
    .string()
    .max(50, { message: t('validation.nameMax') }),
  status: z
    .number(),
});

export const permissionEditSchema = permissionSchema.extend({
 
});

export type PermissionValidationSchema = z.infer<typeof permissionSchema>;
export type PermissionEditValidationSchema = z.infer<typeof permissionEditSchema>;