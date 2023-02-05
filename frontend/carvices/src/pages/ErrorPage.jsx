import { Center, Container, Heading, Text, VStack } from "@chakra-ui/react";
import { Link } from "react-router-dom";

export default function ErrorPage() {
    return (
        <>
            <Container centerContent={true} h={'100vh'} justifyContent="center">
                <VStack>
                    <Heading><Text as="span" textDecor='underline'>404</Text> Not found</Heading>
                    <Text>Sorry page with current route not found. <Link style={{color:'blue'}} to={'/'}>Get back...</Link> </Text>
                </VStack>
            </Container>
        </>
    );
}