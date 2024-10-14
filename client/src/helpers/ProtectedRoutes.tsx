import { Route } from 'react-router-dom';
import { PrivateRoute } from '@/types/components/route';
import { Fragment } from 'react/jsx-runtime';
import DefaultLayout from '@/layouts/DefaultLayout';
import { privateRoutes } from '@/routes/routes';

const ProtectedRoutes = ({ ...props }: PrivateRoute) => {
  return (
    <>
      {privateRoutes.map((route, index) => {
        const Page = route.component;
        let Layout: any = DefaultLayout;

        if (route.layout) {
          Layout = route.layout;
        } else if (route.layout === null) {
          Layout = Fragment;
        }

        if (props.allowedRoles) {
          return (
            <Redirect
              key={index}
              to='/login'
            />
          );
        }

        if (allowedRoles && !allowedRoles.includes(userRole)) {
          return (
            <Redirect
              key={index}
              to='/unauthorized'
            />
          );
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
    </>
  );
};

export default ProtectedRoutes;
