import { createBrowserRouter } from "react-router-dom";
import AuthenticationLayout from "./pages/authentication/AuthenticationLayout";
import LoginPage from "./pages/authentication/LoginPage";
import RegistrationPage from "./pages/authentication/RegistrationPage";
import { BaseLayout } from './pages/BaseLayout';
import ErrorPage from "./pages/ErrorPage";
import { HomePage  } from "./pages/HomePage";

export const router = createBrowserRouter([
    {
        path: '',
        element: <BaseLayout/>,
        errorElement: <ErrorPage/>,
        children: [
            {
                path: '',
                element: <HomePage />
            }
        ],
    },
    {
        path: 'authentication',
        element: <AuthenticationLayout/>,
        children: [
            {
                path: 'login',
                element: <LoginPage />
            },
            {
                path: 'registration',
                element: <RegistrationPage />
            }
        ]
    }
]);