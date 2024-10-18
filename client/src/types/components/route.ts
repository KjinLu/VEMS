import React, { ReactElement, ReactNode } from 'react';
import { Role } from '../auth/type';

export type PublicRoute = {
  path: string;
  component: React.ComponentType;
  layout?: (props: { children: ReactElement }) => JSX.Element | null;
};

export type PrivateRoute = {
  path: string;
  component: React.ComponentType;
  layout?: (props: { children: ReactElement }) => JSX.Element | null;
  isAuthenticated: boolean;
  allowedRoles: Role[];
};

export type PrivateRouteProps = {
  isAuthenticated: boolean;
  allowedRoles: Role[] | null;
};
