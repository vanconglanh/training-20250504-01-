// src/utils/validationSchema.ts
import { z } from 'zod';
import i18next from 'i18next';

const t = i18next.t.bind(i18next);

export const userSchema = z.object({
    name: z
    .string()
    .max(255, { message: t('validation.nameMax') }),
  email: z
    .string()
    .max(255, { message: t('validation.emailMax') }),
  username: z
    .string()
    .max(255, { message: t('validation.usernameMax') }),
  language: z
    .string()
    .min(1, {message: t('validation.languageMin') }) 
    .max(20, { message: t('validation.languageMax') }),
  password: z
    .string()
    .max(255, { message: t('validation.passwordMax') }),
  passwordHash: z
    .string()
    .max(255, { message: t('validation.passwordHashMax') }),
  roleId: z
    .number()
    .min(1, {message: t('validation.roleIdMin') }) ,
  status: z
    .number(),
});

export const userEditSchema = userSchema.extend({
 
});

export type UserValidationSchema = z.infer<typeof userSchema>;
export type UserEditValidationSchema = z.infer<typeof userEditSchema>;