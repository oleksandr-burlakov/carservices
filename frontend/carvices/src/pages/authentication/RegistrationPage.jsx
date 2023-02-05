import { CardBody, Flex, Button, Heading, FormControl, FormLabel, Input, Box, Text, Icon, RadioGroup, VStack, Radio, Stack } from "@chakra-ui/react";
import { Step, Steps, useSteps } from "chakra-ui-steps"
import { useState } from "react";
import { FaStar } from "@react-icons/all-files/fa/FaStar";
import { FaUser } from "@react-icons/all-files/fa/FaUser";
import { FaBriefcase } from "@react-icons/all-files/fa/FaBriefcase";

function GeneralInfoRegistration({
        username, setUsername, 
        email, setEmail, 
        password, setPassword}) {
    return (
        <>
            <Heading as="h1" size="lg" textAlign="center">Please register</Heading>
            <form>
                <FormControl>
                    <FormLabel display='flex' alignItems='center' gap='5px' marginTop="10px" marginBottom='0px'><Icon color='red.400' as={FaStar}/>Username</FormLabel>
                    <Input type="text" value={username} onInput={(e) => setUsername(e.target.value)} />
                </FormControl>
                <FormControl>
                    <FormLabel display='flex' alignItems='center' gap='5px' marginTop="10px" marginBottom='0px'><Icon color='red.400' as={FaStar}/>Email</FormLabel>
                    <Input type="email" value={email} onInput={(e) => setEmail(e.target.value)} />
                </FormControl>
                <FormControl>
                    <FormLabel display='flex' alignItems='center' gap='5px' marginTop="10px" marginBottom='0px'><Icon color='red.400' as={FaStar}/>Password</FormLabel>
                    <Input type="password" value={password} onInput={(e) => setPassword(e.target.value)} />
                </FormControl>
            </form>
        </>
    );
}

function RoleInformationRegistration({setRole}) {
    return (
        <>
            <FormControl>
                <FormLabel>You are</FormLabel>
                <RadioGroup onChange={setRole}>
                    <Stack>
                        <Radio value='0'>Service owner</Radio>
                        <Radio value='1'>Client</Radio>
                        <Radio value='2'>Worker</Radio>
                    </Stack>
                </RadioGroup>
            </FormControl>
        </>
    );
}

const validateEmail = (email) => {
    return String(email)
      .toLowerCase()
      .match(
        /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
      );
  };

export default function RegistrationPage() {
    const { nextStep, prevStep, reset, activeStep } = useSteps({
      initialStep: 0,
    })

    const [username, setUserName] = useState('');
    const [password, setPassword] = useState('');
    const [email, setEmail] = useState('');
    const [role, setRole] = useState(null);

    const isFormValid = function() {
        return (username && password && email && validateEmail(email));
    }

    const validateInfoRegistraion = function() {
        if (isFormValid()) {
            nextStep();
        }
        return false;
    }

    const isRoleValid = function() {
        return (role !== null);
    }

    const validateRoleRegistration = function() {
        if (isRoleValid()) {
            nextStep();
        }
        return false;
    };

    return (
      <>
        <CardBody>
            <Flex flexDir="column" width="100%">
                <Steps activeStep={activeStep}>
                    <Step label='Login information' key={0} icon={FaUser}>
                        <Box marginY="20px">
                            <GeneralInfoRegistration 
                                setEmail={setEmail} email={email}
                                setPassword={setPassword} password={password}
                                setUsername={setUserName} username={username}
                                />
                        </Box>
                    </Step>
                    <Step label='Get to know you' key={1} icon={FaBriefcase}>
                        <Box marginY="20px">
                            <RoleInformationRegistration setRole={setRole}/>
                        </Box>
                    </Step>
                </Steps>
                <Flex width="100%" justify="flex-end">
                    <Button
                        isDisabled={activeStep === 0}
                        mr={4}
                        onClick={prevStep}
                        size="sm"
                        variant="ghost"
                    >
                        Prev
                    </Button>
                    {activeStep == 0 ? (
                        <Button size="sm" onClick={validateInfoRegistraion} isDisabled={!isFormValid()}>
                            Next
                        </Button>
                    ) : (
                        <Button size="sm" onClick={validateRoleRegistration} isDisabled={!isRoleValid() }>
                            Save
                        </Button>
                    )}
                </Flex>
            </Flex>
        </CardBody>
      </>  
    );
}