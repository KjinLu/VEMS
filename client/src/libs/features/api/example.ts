// import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';
// import { axiosPublic } from '@/libs/axios/axiosPublic';

// export const fetchData = createAsyncThunk(
//   'data/fetchData',
//   async (params, { getState }) => {
//     const { data } = await axiosPublic.get('https://reqres.in/api/users?page=1', {
//       params
//     });
//     return data;
//   }
// );

// const dataSlice = createSlice({
//   name: 'data',
//   initialState: {
//     data: null,
//     status: 'idle'
//   },
//   reducers: {},
//   extraReducers: builder => {
//     builder
//       .addCase(fetchData.pending, state => {
//         state.status = 'loading';
//       })
//       .addCase(fetchData.fulfilled, (state, action) => {
//         state.status = 'succeeded';
//         state.data = action.payload; // Lưu data vào redux
//       })
//       .addCase(fetchData.rejected, state => {
//         state.status = 'failed';
//       });
//   }
// });

// export default dataSlice.reducer;
