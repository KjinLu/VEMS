export type SignInProps = {
  username: string;
  password: string;
};

export type getUserProps = {
  accessToken: string;
};

export type Role = 'ADMIN' | 'TEACHER' | 'STUDENT';
