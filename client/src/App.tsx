import { Fragment, useState } from 'react';
import './App.css';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import { privateRoutes, publicRoutes } from './routes/routes';
import DefaultLayout from './layouts/DefaultLayout';

function App() {
  return (
    <BrowserRouter>
      <div className='App'>
        <Routes>
          {publicRoutes.map((route, index) => {
            //Biến sửa dụng với JSX phải viết hoa chữ cái đầu
            const Page = route.component;

            let Layout: any = DefaultLayout;

            if (route.layout) {
              Layout = route.layout;
            } else if (route.layout === null) {
              Layout = Fragment;
            }

            return (
              <Route
                key={index}
                path={route.path}
                element={
                  <Layout>
                    <Page />
                  </Layout>
                }
              />
            );
          })}
        </Routes>
      </div>
    </BrowserRouter>
  );
}

export default App;
