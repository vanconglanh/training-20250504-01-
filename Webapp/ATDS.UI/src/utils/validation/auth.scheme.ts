import { z } from "zod";

export const loginSchema = z.object({
    username: z.string().min(1, 'auth.usernameRequired'),
    password: z.string().min(1, 'auth.passwordRequired'),
  });