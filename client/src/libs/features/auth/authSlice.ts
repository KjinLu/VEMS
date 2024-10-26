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
}

const initialState: AuthState = {
  accountID: null,
  username: null,
  email: null,
  image: null,
  roleID: null,
  roleName: null,
  isFisrtLogin: false,
  classroomID: null
};

const authSlice = createSlice({
  name: 'auth',
  initialState,
  reducers: {
    setCredentials: (state, action: PayloadAction<AuthState>) => {
      Object.assign(state, action.payload);
    },
    setAvatar: (state, action: PayloadAction<string>) => {
      state.image = action.payload;
    },
    logout: () => initialState
  }
});

export const { setCredentials, logout } = authSlice.actions;
export default authSlice.reducer;
