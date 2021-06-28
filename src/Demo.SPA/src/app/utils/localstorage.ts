export class LocalStorageUtils {
    
    public obterUsuario() {
        return JSON.parse(localStorage.getItem('Demo.user'));
    }

    public salvarDadosLocaisUsuario(response: any) {
        this.salvarTokenUsuario(response.accessToken);
        this.salvarUsuario(response.userToken);
    }

    public limparDadosLocaisUsuario() {
        localStorage.removeItem('Demo.token');
        localStorage.removeItem('Demo.user');
    }

    public obterTokenUsuario(): string {
        return localStorage.getItem('Demo.token');
    }

    public salvarTokenUsuario(token: string) {
        localStorage.setItem('Demo.token', token);
    }

    public salvarUsuario(user: string) {
        localStorage.setItem('devDemoio.user', JSON.stringify(user));
    }

}