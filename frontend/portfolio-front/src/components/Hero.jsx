import { useRef, Suspense } from 'react';
import { Canvas, useFrame } from '@react-three/fiber';
import { useGLTF, Environment, ContactShadows } from '@react-three/drei';
import './Hero.css';

function BridgeModel() {
  const meshRef = useRef();
  
  // Carrega o modelo GLB
  const { scene } = useGLTF('/src/components/bridge.glb');

  useFrame((state, delta) => {
    if (meshRef.current) {
      // Rotação contínua suave no eixo Y
      meshRef.current.rotation.y += delta * 0.3;
    }
  });

  return (
    <primitive 
      ref={meshRef} 
      object={scene} 
      scale={1.5}
      position={[0, -1.5, 0]}
      rotation={[0.3, 0, 0.15]}
    />
  );
}

function Hero() {
  return (
    <div className="hero-container">
      <div className="hero-content">
        <h1 className="hero-title">Meu Portfólio</h1>
        <p className="hero-subtitle">Desenvolvedor Full Stack</p>
        <p className="hero-description">
          Criando experiências digitais incríveis com código limpo e design moderno
        </p>
      </div>
      
      <div className="canvas-wrapper">
        <Canvas 
          camera={{ position: [0, 0, 6], fov: 50, near: 0.1, far: 1000 }}
          dpr={[1, 2]}
        >
          <ambientLight intensity={0.6} />
          <directionalLight position={[5, 5, 5]} intensity={1.2} castShadow />
          <directionalLight position={[-5, 5, -5]} intensity={0.5} />
          <pointLight position={[-5, -5, -5]} intensity={0.8} color="#818cf8" />
          <spotLight position={[0, 10, 0]} intensity={0.6} color="#c7d2fe" angle={0.3} />
          
          <Suspense fallback={null}>
            <BridgeModel />
            <ContactShadows 
              position={[0, -3, 0]} 
              opacity={0.3} 
              scale={20} 
              blur={2.5} 
              far={6}
            />
            <Environment preset="sunset" />
          </Suspense>
        </Canvas>
      </div>
    </div>
  );
}

export default Hero;