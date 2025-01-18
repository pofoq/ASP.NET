import React from "react";

interface TextProps {
    setup: string;
    punchline: string;
}

const TextComponent: React.FC<TextProps> = (TextProps) => {
    return (
        <div>
            <div style={{ backgroundColor: 'grey', color: 'white', padding: '10px' }}>
                {TextProps.setup}
            </div>
            <div style={{ backgroundColor: 'green', color: 'white', padding: '10px' }}>
                {TextProps.punchline}
            </div>
        </div>
    );
};

export default TextComponent;
