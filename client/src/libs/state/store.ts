import { combineReducers, configureStore } from '@reduxjs/toolkit';
import { setupListeners } from '@reduxjs/toolkit/query/react';
import storage from 'redux-persist/lib/storage';
import { persistReducer } from 'redux-persist';
import persistStore from 'redux-persist/es/persistStore';

// Import new reducer
import { authApi } from '@/services/auth';
import authReducer from '@/libs/features/auth/authSlice';
import { scheduleApi } from '@/services/schedule';
import { attendanceApi } from '@/services/attendance';
import { profileApi } from '@/services/profile';

const persistConfig = {
  key: 'root',
  storage
};

const rootReducer = combineReducers({
  auth: authReducer,
  [authApi.reducerPath]: authApi.reducer,
  [scheduleApi.reducerPath]: scheduleApi.reducer,
  [attendanceApi.reducerPath]: attendanceApi.reducer,
  [profileApi.reducerPath]: profileApi.reducer
});

const persistedReducer = persistReducer(persistConfig, rootReducer);

export const store = configureStore({
  reducer: persistedReducer,
  middleware: (getDefaultMiddleware: any) => {
    return getDefaultMiddleware({ serializableCheck: false }).concat(
      authApi.middleware,
      scheduleApi.middleware,
      attendanceApi.middleware,
      profileApi.middleware
    );
  }
});

setupListeners(store.dispatch);

export const persistor = persistStore(store);

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;

export default store;
