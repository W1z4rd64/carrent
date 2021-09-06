import http from 'k6/http';
import { sleep } from 'k6';

export let options = {
    stages: [
        { duration: '1m', target: 20 },
        { duration: '2m', target: 50 },
        { duration: '2m', target: 100 },
        { duration: '1m', target: 20 },
    ],
};

export default function () {
    http.get('https://localhost:44360/api/carclass');
    sleep(1);
}