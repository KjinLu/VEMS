import { createSlice, PayloadAction } from '@reduxjs/toolkit';

interface AuthState {
  role: string | null;
}

const initialState: AuthState = {
  role: null
};

const authSlice = createSlice({
  name: 'auth',
  initialState,
  reducers: {
    setCredentials: (state, action: PayloadAction<{ role: string }>) => {
      state.role = action.payload.role;
    },
    logout: state => {
      state.role = null;
    }
  }
});

export const { setCredentials, logout } = authSlice.actions;
export default authSlice.reducer;
