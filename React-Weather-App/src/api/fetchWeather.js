import axios from 'axios';


const API_KEY = '58c23e86dc8921202199f3dda78280e0';
const URL = 'https://api.openweathermap.org/data/2.5/weather';


export const fetchWeather = async (query) => {
    const {data} = await axios.get(URL, {
        params: {
            q: query,
            units: 'metric',
            appId: API_KEY,
        } 
    });

    return data;

}