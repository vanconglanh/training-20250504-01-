import { Box, Button, Container, Typography } from '@mui/material';
import { useTranslation } from 'react-i18next';
import { useNavigate } from 'react-router-dom';
import forbiddenImage from '@/assets/forbidden.png'; // Make sure path is correct

const Forbidden = () => {
  const { t } = useTranslation();
  const navigate = useNavigate();

  return (
    <Container maxWidth="md">
      <Box
        sx={{
          display: 'flex',
          flexDirection: 'column',
          alignItems: 'center',
          justifyContent: 'center',
          minHeight: '100vh',
          textAlign: 'center',
          py: 4
        }}
      >
        {/* Forbidden image illustration */}
        <Box
          component="img"
          src={forbiddenImage}
          alt="403 Forbidden"
          sx={{
            maxWidth: 300,
            width: '100%',
            mb: 4
          }}
        />

        <Typography variant="h5" component="h2" gutterBottom>
        {t('errors.insufficientPermissions')}
        </Typography>

        <Button
          variant="contained"
          color="primary"
          onClick={() => navigate('/dashboard')}
          sx={{ mt: 2 }}
        >
          {t('common.backToHome')}
        </Button>
      </Box>
    </Container>
  );
};

export default Forbidden;
