import { AddsignPipe } from './addsign.pipe';

fdescribe('AddsignPipe', () => {
  const pipe = new AddsignPipe();
  it('create an instance', () => { 
    expect(pipe).toBeTruthy();
  });

  it('transforms 2000 to Rs. 2000', () => {
    expect(pipe.transform('2000')).toBe("Rs. 2000");
   });
});
