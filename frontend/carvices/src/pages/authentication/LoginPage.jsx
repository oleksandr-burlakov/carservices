import { Center, Card, CardHeader, Heading, CardBody, FormControl, FormLabel, Input, Button, Text } from "@chakra-ui/react";
import { Link } from "react-router-dom";
import { useState } from "react";

export default function LoginPage() {
    const [login, setLogin] = useState('');
    const [password, setPassword] = useState('');

    const isValid = function() {
        if (login && password) {
            return true;
        }
        return false;
    };

    return (
        <>
            <CardHeader textAlign='center'>
                <Heading as="h1" size="lg">Please, Sign-in</Heading>
            </CardHeader>
            <CardBody>
                <form>
                    <FormControl>
                        <FormLabel>Login</FormLabel>
                        <Input type="text" value={login} onInput={(e) => setLogin(e.target.value)}/>
                    </FormControl>
                    <FormControl marginBottom='10px'>
                        <FormLabel>Password</FormLabel>
                        <Input type="password" value={password} onInput={(e) => setPassword(e.target.value)}/>
                    </FormControl>
                    <Text><Link to="../forgot-password">Forgot password?</Link></Text>
                    <FormControl marginY='10px'>
                        <Button colorScheme='purple' variant='outline' width='full' isDisabled={!isValid()}>Sign in</Button>
                    </FormControl>
                </form>
                <Text marginTop='20px' textAlign='right'>Don't have account? <Link to="../registration" style={{textDecoration: 'underline'}}>Register</Link> </Text>
            </CardBody>
        </>
    );
}