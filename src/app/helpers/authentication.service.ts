import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  isLoggedIn() {
    const user = localStorage.getItem('token');
    if (user) {
        return true;
    }

    return false;
}

getToken() {
    const token = localStorage.getItem('token')
    console.log(token)
    return token
}
}
