import axios, { AxiosResponse } from "axios";
import { Activity } from "../models/activity";

axios.defaults.baseURL = "https://localhost:5001/api";

axios.interceptors.response.use(async response => {
    try {
        return response;
    } catch (error) {
        console.log(error);
        return await Promise.reject(error);
    }
})

const responseBody = <T>(response: AxiosResponse<T>) => response.data;

const requests = {
    get: <T>(url: string) => axios.get<T>(url).then(responseBody),
    post: <T>(url: string, body: {}) =>
        axios.post<T>(url, body).then(responseBody),
    put: <T>(url: string, body: {}) => axios.put<T>(url, body).then(responseBody),
    del: <T>(url: string) => axios.delete<T>(url).then(responseBody),
};

const Activities = {
    list: () => requests.get<Activity[]>("/Events/GetAll"),
    details: (id: string) => requests.get<Activity>(`/Events/GetById/${id}`),
    create: (activity: Activity) => requests.post<void>("/Events/Create",activity),
    update: (activity: Activity) => requests.put<void>("/Events/Update",activity),
    delete: (id: string) => requests.del<void>(`/Events/Delete/${id}`)
};

const agent = {
    Activities
};

export default agent;
