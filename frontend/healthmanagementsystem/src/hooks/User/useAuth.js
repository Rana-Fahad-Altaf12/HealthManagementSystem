import { useSelector } from 'react-redux';

const useAuth = () => {
    const currentUser  = useSelector((state) => state.user.currentUser );
    return { currentUser  };
};

export default useAuth;
