import { Box, Button, Container, Typography } from '@mui/material';
import Grid from '@mui/material/Grid';
import { useTranslation } from 'react-i18next';
import { useNavigate } from 'react-router-dom';
import notFoundImage from '@/assets/not-found.png';

export default function NotFound() {
  const { t } = useTranslation();
  const navigate = useNavigate();

  const handleGoHome = () => {
    navigate('/dashboard');
  };

  return (
    <Box
      sx={{
        display: 'flex',
        justifyContent: 'center',
        alignItems: 'center',
        minHeight: '100vh'
      }}
    >
      <Container maxWidth="md">
        <Grid container spacing={2}>
          <Grid size={6}>
            <Typography variant="h1">
              404
            </Typography>
            <Typography variant="h6">
              {t('common.notFound')}
            </Typography>
            <Button 
              variant="contained"
              onClick={handleGoHome}
              sx={{ mt: 2 }}
            >
              {t('common.backToHome')}
            </Button>
          </Grid>
          <Grid size={6}>
            <img
              src={notFoundImage}
              alt="404 Error"
              style={{
                width: '100%',
                height: 'auto',
                objectFit: 'contain'
              }}
            />
          </Grid>
        </Grid>
      </Container>
    </Box>
  );
}