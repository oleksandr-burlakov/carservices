import { Container, HStack, Stack, StackItem, Image } from "@chakra-ui/react";
import { Link, Outlet } from "react-router-dom";

export function BaseLayout() {
    return (
        <>
            <Stack
                direction={'column'}
                >
                <HStack paddingX="2rem" 
                    className="header-links"
                    justify='space-between' backgroundColor='purple.600' 
                    borderBottom="1px" borderBottomColor="red.400">
                    <StackItem color='yellow.500' fontSize='22px' fontWeight='bold'>
                        <Link to={'/'}>
                            <Image src={window.location.origin + '/assets/Logo-Text.svg'} padding='20px' />
                        </Link>
                    </StackItem>
                    <StackItem color='white' fontWeight='normal' fontSize='18px'>
                        <Link to={'/authentication/login'} style={{padding:'23px'}}>
                            Sign-in
                        </Link>
                    </StackItem>
                </HStack>
                <StackItem>
                    <Container maxW='100%'>
                        <Outlet />
                    </Container>
                </StackItem>
            </Stack>
            
        </>
    );
}