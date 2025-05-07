// src/utils/validationSchema.ts
import { z } from 'zod';
import i18next from 'i18next';

const t = i18next.t.bind(i18next);

export const userSchema = z.object({
  username: z
    .string()
    .min(3, { message: t('validation.usernameMin') })
    .max(50, { message: t('validation.usernameMax') }),
  email: z
    .string()
    .email({ message: t('validation.emailInvalid') }),
  password: z
    .string()
    .min(8, { message: t('validation.passwordMin') })
    .regex(/[A-Z]/, { message: t('validation.passwordUppercase') })
    .regex(/[a-z]/, { message: t('validation.passwordLowercase') })
    .regex(/[0-9]/, { message: t('validation.passwordNumber') })
    .regex(/[^A-Za-z0-9]/, { message: t('validation.passwordSpecial') })
    .optional(),
  role: z
    .string()
    .min(1, { message: t('validation.roleRequired') }),
  status: z
    .string()
    .min(1, { message: t('validation.statusRequired') }),
  yukoFlag: z
    .boolean()
    .default(false),
});

export const userEditSchema = userSchema.extend({
  password: z
    .string()
    .min(8, { message: t('validation.passwordMin') })
    .regex(/[A-Z]/, { message: t('validation.passwordUppercase') })
    .regex(/[a-z]/, { message: t('validation.passwordLowercase') })
    .regex(/[0-9]/, { message: t('validation.passwordNumber') })
    .regex(/[^A-Za-z0-9]/, { message: t('validation.passwordSpecial') })
    .or(z.literal(''))
    .optional(),
});

export type UserValidationSchema = z.infer<typeof userSchema>;
export type UserEditValidationSchema = z.infer<typeof userEditSchema>;