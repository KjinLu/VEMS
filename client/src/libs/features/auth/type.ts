export interface UserData {
  email: string;
  password: string;
}

export interface LoginResult {
  login: (userData: UserData) => Promise<void>;
  isLoading: boolean;
  error: string | null;
}
