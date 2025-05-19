// src/utils/validationSchema.ts
import { z } from 'zod';
import i18next from 'i18next';

const t = i18next.t.bind(i18next);

export const screenSchema = z.object({
    name: z
    .string()
    .max(50, { message: t('validation.nameMax') }),
  status: z
    .number(),
});

export const screenEditSchema = screenSchema.extend({
 
});

export type ScreenValidationSchema = z.infer<typeof screenSchema>;
export type ScreenEditValidationSchema = z.infer<typeof screenEditSchema>;