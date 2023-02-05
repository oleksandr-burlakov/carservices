import { Center, Card, Text, Button } from "@chakra-ui/react";
import { Outlet } from "react-router-dom";
import { Link } from "react-router-dom";

export default function AuthenticationLayout() {
    return (
        <Center height='100vh' flexDirection='column'>
            <Card width='container.sm'>
                <Outlet />
            </Card>

            <Text marginY='10px'>
                <Link to={'/'}>
                    <Button colorScheme='pink' variant='ghost'>Get back</Button>
                </Link>
            </Text>
        </Center>
    );
}