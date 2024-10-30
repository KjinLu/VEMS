import { Route, Navigate, Routes, useLocation } from 'react-router-dom';
import { PrivateRouteProps } from '@/types/components/route';
import { Fragment } from 'react/jsx-runtime';
import { privateRoutes, publicRoutes } from '@/routes/routes';
import { configAuthorise, configError, configRoutes } from '@/constants/routes';
import NullLayout from '@/layouts/NullLayout';
import { useEffect, useState } from 'react';
import Cookies from 'js-cookie';
import path from 'path';

const ProtectedRoutes = ({ isAuthenticated, allowedRoles }: PrivateRouteProps) => {
  const isRouteProtected = (path: string) => {
    return configAuthorise.matcher.some(pattern =>
      new RegExp(pattern.replace(':path*', '.*')).test(path)
    );
  };

  const [shouldRender, setShouldRender] = useState<boolean>(true);
  const pathName = useLocation().pathname;

  useEffect(() => {
    setShouldRender(true);
  }, [isAuthenticated, allowedRoles, pathName]);

  return (
    <Routes>
      {!!Cookies.get('accessToken') &&
      !!allowedRoles &&
      (pathName === '/' || pathName === '' || pathName.includes('login')) ? (
        allowedRoles.includes('ADMIN') ? (
          <Route
            key={'ADMIN'}
            path={pathName}
            element={<Navigate to={configRoutes.ScheduleManagementPage} />}
          />
        ) : allowedRoles.includes('TEACHER') ? (
          <Route
            key={'TEACHER'}
            path={pathName}
            element={<Navigate to={configRoutes.home} />}
          />
        ) : allowedRoles.includes('STUDENT') ? (
          <Route
            key={'STUDENT'}
            path={pathName}
            element={<Navigate to={configRoutes.studentSchedule} />}
          />
        ) : null
      ) : (
        <Route
          key={'Login'}
          path={'/'}
          element={<Navigate to={configRoutes.login} />}
        />
      )}

      {privateRoutes.map((route, index) => {
        const Page = route.component;
        let Layout: any = NullLayout;

        if (route.layout) {
          Layout = route.layout;
        } else if (route.layout === null) {
          Layout = Fragment;
        }

        if (pathName === route.path && !shouldRender) {
          setShouldRender(false);
        }

        if (isRouteProtected(route.path) && !isAuthenticated) {
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
        }

        if (allowedRoles && pathName === route.path) {
          if (route.allowedRoles.some(role => allowedRoles.includes(role))) {
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
          } else {
            return (
              <Route
                key={index}
                path={route.path}
                element={<Navigate to={configError.UnAuthorize} />}
              />
            );
          }
        }
      })}

      {shouldRender &&
        publicRoutes.map((route, index) => {
          const Page = route.component;
          let Layout: any = NullLayout;

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

      <Route
        path='*'
        element={<Navigate to={configError.NotFound} />}
      />
    </Routes>
  );
};

export default ProtectedRoutes;
