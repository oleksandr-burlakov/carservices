import { extendTheme } from "@chakra-ui/react";
import { mode } from "@chakra-ui/theme-tools";
import { StepsTheme as Steps } from "chakra-ui-steps";

export const theme = extendTheme({
  components: {
    Steps,
  },
  styles: {
    global: (props) => ({
      body: {
        bg: mode('#FAF5FF','#322659')(props),
      }
    })
  },
})