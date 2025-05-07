import { useForm, UseFormProps, FieldPath, FieldValues } from 'react-hook-form';
import { zodResolver } from '@hookform/resolvers/zod';
import { z } from 'zod';
import { useTranslation } from 'react-i18next';
import { useSnackbar } from 'notistack';

/**
 * A custom hook that combines react-hook-form with zod validation
 * @param schema The zod schema to validate against
 * @param options Additional options for useForm
 * @returns The form methods with error handling and translation
 */
export function useZodForm<
  TSchema extends z.ZodType,
  TFieldValues extends FieldValues = z.infer<TSchema>,
  TContext = any
>(
  schema: TSchema,
  options?: Omit<UseFormProps<TFieldValues, TContext>, 'resolver'>
) {
  const { t } = useTranslation();
  const { enqueueSnackbar } = useSnackbar();

  const form = useForm<TFieldValues, TContext>({
    ...options,
    resolver: zodResolver(schema),
  });

  const { handleSubmit } = form;

  const handleSubmitWithErrorMessage = (
    onValid: (data: TFieldValues) => void | Promise<void>,
    onInvalid?: (errors: any) => void
  ) => {
    return handleSubmit(
      onValid,
      (errors) => {
        // Show a notification for the first error
        const fieldNames = Object.keys(errors);
        if (fieldNames.length > 0) {
          const firstFieldWithError = fieldNames[0] as FieldPath<TFieldValues>;
          const errorMessage = errors[firstFieldWithError]?.message as string;
          
          if (errorMessage) {
            enqueueSnackbar(t(errorMessage) || errorMessage, { variant: 'error' });
          } else {
            enqueueSnackbar(t('errors.invalidForm'), { variant: 'error' });
          }
        }
        
        // Call custom onInvalid handler if provided
        if (onInvalid) {
          onInvalid(errors);
        }
      }
    );
  };

  return {
    ...form,
    handleSubmitWithErrorMessage,
  };
}