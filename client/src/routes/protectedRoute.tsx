import { Navigate } from "react-router-dom";

interface ProtectedRouteProps{
    children: JSX.Element;
    roles?: string[];
}

const ProtectedRoute = ({children, roles = []}: ProtectedRouteProps) =>{
    const accessToken = localStorage.getItem('access_token');
    const userRole = localStorage.getItem('userRole');

    if (!accessToken || (roles.length && !roles.includes(userRole || ''))) {
        return <Navigate to="/login" replace />;
      }
    
      return children;
    };
    
    export default ProtectedRoute;