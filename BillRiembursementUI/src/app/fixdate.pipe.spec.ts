import { FixdatePipe } from './fixdate.pipe';

fdescribe('FixdatePipe', () => {
  const pipe = new FixdatePipe();

  it('create an instance', () => { 
    expect(pipe).toBeTruthy();
  });

  it('transforms 25-05-2018T00:00:00:00 to 25-05-2018', () => {
   expect(pipe.transform('25-05-2018T00:00:00:00')).toBe("25-05-2018");
  });



});
