import { ThirdTryPage } from './app.po';

describe('third-try App', () => {
  let page: ThirdTryPage;

  beforeEach(() => {
    page = new ThirdTryPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!');
  });
});
