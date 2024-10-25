import { createSlice, PayloadAction } from '@reduxjs/toolkit';

interface AuthState {
  accountID: string | null;
  username: string | null;
  email: string | null;
  image: string | null;
  roleID: string | null;
  roleName: string | null;
  isFisrtLogin: boolean;
  classroomID?: string | null;
  fullName?: string | null;
  studentType?: string | null;
}

const initialState: AuthState = {
  accountID: null,
  username: null,
  email: null,
  image: null,
  roleID: null,
  roleName: null,
  isFisrtLogin: false,
  classroomID: null,
  fullName: null,
  studentType: null
};

const authSlice = createSlice({
  name: 'auth',
  initialState,
  reducers: {
    setCredentials: (state, action: PayloadAction<AuthState>) => {
      Object.assign(state, action.payload);
    },
    logout: () => initialState
  }
});

export const { setCredentials, logout } = authSlice.actions;
export default authSlice.reducer;
