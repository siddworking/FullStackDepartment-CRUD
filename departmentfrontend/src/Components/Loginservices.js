import axios from "axios";

const base_url2 = 'http://localhost:5279/';
class Loginservices{
    getLogins(){
        return axios.get(base_url2+"Logins");
    }
}

export default new Loginservices();