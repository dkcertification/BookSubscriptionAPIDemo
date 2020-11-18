import {AccountService} from 'src/app/_services/account.service'

export function appInitializer(accountService: AccountService) {
    return () => new Promise(resolve => {
        // attempt to refresh token on app start up to auto authenticate
        accountService.refreshToken()
            .subscribe()
            .add(resolve);
    });
}