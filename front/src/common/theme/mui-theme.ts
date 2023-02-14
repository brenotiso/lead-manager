import { createTheme } from '@mui/material';
import { ptBR as corePtBR } from '@mui/material/locale';

export const muiTheme = createTheme(
  {
    palette: {
      primary: {
        main: '#FE7D2B'
      },
      secondary: { main: '#D46823' }
    },
    typography: {
      fontFamily: ['Roboto'].join(',')
    }
  },
  corePtBR
);
