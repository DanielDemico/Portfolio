import HeroSection from './components/Hero.jsx';


function App() {
  return (
    <div style={{display: 'flex', flexDirection: 'column', alignItems: 'center', justifyContent: 'center', width: '100vw', height: '100vh'}}>
      
      <div>
        <HeroSection />
      </div>
      <div>
        <p> Some content here </p>
      </div>
    </div>
  );
}
export default App;