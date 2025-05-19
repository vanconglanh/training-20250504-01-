// src/utils/validationSchema.ts
import { z } from 'zod';
import i18next from 'i18next';

const t = i18next.t.bind(i18next);

export const roleSchema = z.object({
    name: z
    .string()
    .max(30, { message: t('validation.nameMax') }),
  isSystem: z
    .number()
    .min(1, {message: t('validation.isSystemMin') }) ,
  status: z
    .number(),
});

export const roleEditSchema = roleSchema.extend({
 
});

export type RoleValidationSchema = z.infer<typeof roleSchema>;
export type RoleEditValidationSchema = z.infer<typeof roleEditSchema>;