import axios from 'axios';

const appReady = async () => {
    return await axios.get('http://localhost:5028/api/info/ready');
}

export default appReady;